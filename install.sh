#!/bin/bash

set -e

echo -e "-- Preserving existing installation\n"

INSTALL_DIRECTORY=~/software/list-new-penpals

if [ -e $INSTALL_DIRECTORY ]
then
    mv -v $INSTALL_DIRECTORY $INSTALL_DIRECTORY-old
fi

SYM_LINK=~/software/bin/list-new-penpals

if [ -h $SYM_LINK ]
then
    mv -v $SYM_LINK $SYM_LINK-old
fi

echo ""

echo -e "-- Installing new version\n"

BUILD_DIRECTORY=App/bin/Release/net9.0

mkdir -v $INSTALL_DIRECTORY && \
    cp -v $BUILD_DIRECTORY/App $INSTALL_DIRECTORY && \
    cp -v $BUILD_DIRECTORY/App.dll $INSTALL_DIRECTORY && \
    cp -v $BUILD_DIRECTORY/FSharp.Core.dll $INSTALL_DIRECTORY && \
    cp -v $BUILD_DIRECTORY/App.deps.json $INSTALL_DIRECTORY && \
    cp -v $BUILD_DIRECTORY/App.runtimeconfig.json $INSTALL_DIRECTORY && \
    ln -v -s $INSTALL_DIRECTORY/App $SYM_LINK

echo ""

if [ "$?" -eq 0 ]
then
    echo -e "-- Cleaning up\n"

    rm -v -rf $INSTALL_DIRECTORY-old
    rm -v $SYM_LINK-old
else
    echo -e "-- Restoring existing installation\n"

    rm -rf $INSTALL_DIRECTORY
    mv $INSTALL_DIRECTORY-old $INSTALL_DIRECTORY
    mv $SYM_LINK-old $SYM_LINK
fi
