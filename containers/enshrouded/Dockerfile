FROM steamcmd/steamcmd:debian-trixie

EXPOSE 15637

RUN apt update
RUN apt upgrade -y
RUN apt-get install -y wget gpg

# Install Wine
RUN mkdir -pm755 /etc/apt/keyrings
RUN wget -O - https://dl.winehq.org/wine-builds/winehq.key | gpg --dearmor -o /etc/apt/keyrings/winehq-archive.key -
RUN dpkg --add-architecture i386
RUN wget -NP /etc/apt/sources.list.d/ https://dl.winehq.org/wine-builds/debian/dists/trixie/winehq-trixie.sources
RUN apt update
RUN apt-get install -y --install-recommends winehq-stable

# Enshrouded
RUN mkdir /enshrouded

COPY run.sh /run.sh
RUN chmod a+x /run.sh

ENTRYPOINT [ "/run.sh" ]