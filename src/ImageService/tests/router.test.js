const express = require('express');
const routes = require('../api/v1/router');
const request = require('supertest');
const mongoose = require('mongoose');
const imageModel = require('../models/Image');

const app = express();

app.use('api/v1', routes);

beforeAll(async () => {
  const full_url =
    process.env.MONGO_URL.split('/').slice(0, -1).join('/') +
    '/' +
    global.__MONGO_DB_NAME__;
  await mongoose.connect(full_url, {
    useNewUrlParser: true,
    useCreateIndex: true,
    useUnifiedTopology: true,
    poolSize: 20,
  });
});

afterAll(async () => {
  await mongoose.connection.close();
});

beforeEach(async () => {
  for (const key in mongoose.connection.collections) {
    await mongoose.connection.collections[key].deleteMany();
  }
});

describe('Testing server endpoints', () => {
  test('should do nothing', async () => {
    const image = new imageModel({
      UserId: 'test',
      ProductId: 'test-product',
      ImageUrl: 'no',
    });
    await image.save();
    console.log(await imageModel.find());
  });
});
