const mongoose = require('mongoose');

const { Schema, model } = mongoose;

const imageSchema = new Schema({
  UserId: String,
  ProductId: String,
  ImageUrl: String,
});

const Image = model('image', imageSchema, 'Images');

module.exports = Image;
