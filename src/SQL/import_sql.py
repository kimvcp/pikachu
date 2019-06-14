#!/usr/bin/python

import os
from time import sleep
from string import Template
from operator import itemgetter
import logging
import commands

dir_path = os.path.dirname(os.path.realpath(__file__))
wait_time=15
password="Monday1!"
import_sql_call_template=Template('/opt/mssql-tools/bin/sqlcmd -S 0.0.0.0 -d $db -U sa -P $password -i "$file"')
logging_template=Template('importing to db $db from file $file. $output')

logging.basicConfig(filename='output.log', filemode='w', level=logging.DEBUG)

script_order={
        '/user/': 10,
        '/types/': 9,
        '/table_schema/': 8,	
        '/constraints/': 7,			 
        '/stored procedures/': 6
    }
	
def get_immediate_subdirectories(a_dir):
    return [name for name in os.listdir(a_dir)
            if os.path.isdir(os.path.join(a_dir, name))]

def log_info(message):			
    logging.info(message)
    print('[INFO]' + message)

def log_progress(is_error, file, db, output):
    message = logging_template.substitute(db=db, password=password, file=file, output=output)
    if(is_error):
        logging.error(message)    
        print('[ERROR]' + message)
    else:
        logging.info(message)  
        print('[INFO]' + message)

def import_sql(file, db):       
    status, output = commands.getstatusoutput(import_sql_call_template.substitute(db=db, password=password, file=file))  	
    log_progress(status > 0 or "Level" in output, file, db, output)

def should_include_file(file):
    return file.endswith('.sql')

def get_file_order(file):
    for partial_path, order in script_order.items():        
        if partial_path in file:
            return order
    return 0

def get_sql_files():
    sql_files=[]
    for db_name in get_immediate_subdirectories(os.path.join(dir_path, 'mdc')):    
        for root, dirs, files in os.walk(os.path.join(dir_path, 'mdc', db_name)):
            for file in files:
                if should_include_file(file):
                    full_path=os.path.join(root, file)
                    sql_files.append(tuple((full_path, db_name, get_file_order(full_path))))
    return sorted(sql_files, key=itemgetter(2), reverse=True)

log_info('starting import') 
log_info('wait for SQL Server to come up')  

sleep(wait_time)

import_sql("./init.sql", "master")
                
#for db_name, sql_file_path, _ in get_sql_files():
#    import_sql(db_name, sql_file_path)