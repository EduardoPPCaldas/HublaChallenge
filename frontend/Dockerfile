FROM node:lts-alpine

WORKDIR /app

COPY . /app

RUN npm ci

RUN npm run build

RUN npm install serve -g

EXPOSE 3000

CMD ["npm", "run", "serve"]