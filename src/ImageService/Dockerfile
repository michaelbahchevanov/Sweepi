FROM node:14-alpine

WORKDIR /app

COPY ["yarn.lock", "package.json", "./"]
RUN yarn install --check-files --non-interactive --ignore-optional --frozen-lockfile
COPY . /app
EXPOSE 6969
ENTRYPOINT [ "yarn", "start" ]