#!/bin/bash

DB_FILE=$1

flyway migrate\
       -url="jdbc:sqlite:$DB_FILE"\
       -locations="filesystem:migrations"
