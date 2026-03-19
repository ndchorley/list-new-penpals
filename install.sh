#!/bin/bash

INSTALL_DIRECTORY=$HOME/software/list-new-penpals
NEW_INSTALL_DIRECTORY=$INSTALL_DIRECTORY-new

rm -vrf $NEW_INSTALL_DIRECTORY
mkdir -pv $NEW_INSTALL_DIRECTORY

if [ $? != 0 ]
then
    echo "Could not create new installation directory"
    exit 1
fi

cp -rv App/bin/Release/net10.0/* $NEW_INSTALL_DIRECTORY

if [ $? != 0 ]
then
    echo "Could not copy new version"
    exit 1
fi

OLD_INSTALL_DIRECTORY=$INSTALL_DIRECTORY-old

if [ -e $INSTALL_DIRECTORY ]
then
    mv -v $INSTALL_DIRECTORY $OLD_INSTALL_DIRECTORY

    if [ $? != 0 ]
    then
        echo "Could not move old version"
        exit 1
    fi
fi

mv -v $NEW_INSTALL_DIRECTORY $INSTALL_DIRECTORY

if [ $? != 0 ]
then
    echo "Could not move new version"
    mv -v $OLD_INSTALL_DIRECTORY $INSTALL_DIRECTORY
    exit 1
fi

BINARY_NAME=App
LINK_NAME=list-new-penpals
BIN_DIRECTORY=$HOME/software/bin
OLD_LINK_NAME=$LINK_NAME-old

if [ -e $BIN_DIRECTORY/$LINK_NAME ]
then
    mv -v $BIN_DIRECTORY/$LINK_NAME $BIN_DIRECTORY/$OLD_LINK_NAME

    if [ $? != 0 ]
    then
        echo "Could not move old symlink"
        exit 1
    fi
fi

ln -s $INSTALL_DIRECTORY/$BINARY_NAME $BIN_DIRECTORY/$LINK_NAME

if [ $? != 0 ]
then
    echo "Could not create a new symlink for the binary"
    mv -v $BIN_DIRECTORY/$OLD_$LINK_NAME $BIN_DIRECTORY/$LINK_NAME
    exit 1
fi

rm -vrf $BIN_DIRECTORY/$OLD_LINK_NAME $OLD_INSTALL_DIRECTORY
