#!/bin/bash
export INSTALL_DIR=/zomboid/install
: ${SERVER_NAME:=servertest}
steamcmd +force_install_dir $INSTALL_DIR +login anonymous +app_update 380870 validate +quit
chmod +x $INSTALL_DIR/start-server.sh
$INSTALL_DIR/start-server.sh -servername $SERVER_NAME -cachedir=/zomboid/server