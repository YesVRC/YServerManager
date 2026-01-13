#!/bin/bash
export INSTALL_DIR=/enshrouded
steamcmd +@sSteamCmdForcePlatformType windows +force_install_dir $INSTALL_DIR +login anonymous +app_update 2278520  validate +quit
wine $INSTALL_DIR/enshrouded_server.exe