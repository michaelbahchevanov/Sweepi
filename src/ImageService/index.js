const dotenv = require('dotenv');
const express = require('express');
const cors = require('cors');
const morgan = require('morgan');
const helmet = require('helmet');
const compression = require('compression');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');

dotenv.config();

const middlewares = require('./middlewares/middelwares');
const api = require('./api/v1/router');

const app = express();

const connection = `mongodb+srv://${process.env.DB_USERNAME}:${process.env.DB_PASSWORD}@sweepi-images-cluster.tr5xn.mongodb.net/sweepi-images?retryWrites=true&w=majority`;

mongoose.connect(
  connection,
  { useNewUrlParser: true, useUnifiedTopology: true },
  (error) => {
    if (error) console.log('An error has occured' + error);
  }
);

app.use(cors());
app.use(helmet());
app.use(compression());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(morgan('dev'));

app.use('/api/v1', api);

app.use(middlewares.notFound);
app.use(middlewares.errorHandler);

const port = process.env.PORT || 6969;
app.listen(port, () => console.log(`🚀 App is running on port ${port}`));
