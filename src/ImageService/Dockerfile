FROM node:14-alpine

WORKDIR /app

COPY package.json /app
COPY yarn.lock /app
RUN yarn install
COPY . /app
EXPOSE 6969
ENTRYPOINT [ "yarn", "start" ]