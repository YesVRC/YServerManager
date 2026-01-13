FROM steamcmd/steamcmd:debian-trixie

EXPOSE 16261
EXPOSE 16262

RUN apt update
RUN apt upgrade -y

# Adoptium 25
RUN apt-get install -y wget apt-transport-https gpg
RUN wget -qO - https://packages.adoptium.net/artifactory/api/gpg/key/public | gpg --dearmor | tee /etc/apt/trusted.gpg.d/adoptium.gpg > /dev/null
RUN echo "deb https://packages.adoptium.net/artifactory/deb $(awk -F= '/^VERSION_CODENAME/{print$2}' /etc/os-release) main" | tee /etc/apt/sources.list.d/adoptium.list

RUN apt-get -y install temurin-25-jre

# Zomboid
RUN mkdir /zomboid
RUN mkdir /zomboid/install
RUN mkdir /zomboid/server

COPY ./run.sh /zomboid/run.sh
RUN chmod +x /zomboid/run.sh

ENTRYPOINT [ "/zomboid/run.sh" ]