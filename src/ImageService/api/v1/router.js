const { Router } = require('express');
const imageModel = require('../../models/Image');

const router = Router();

router.post('/images', async (req, res, next) => {
  try {
    const data = req.body;
    const image = new imageModel({
      UserId: data.userId,
      ProductId: data.productId,
      ImageUrl: data.imageUrl,
    });
    const createdEntry = await image.save();
    res.json(createdEntry);
  } catch (error) {
    next(error);
  }
});

router.delete('/images', async (req, res, next) => {
  try {
    const data = req.body;

    if (!data.id) res.sendStatus(400);

    const image = await imageModel.findById({ _id: data.id });

    if (!image) res.sendStatus(404);

    await image.remove();
    res.sendStatus(204);
  } catch (error) {
    next(error);
  }
});

router.post('/images/all', async (req, res, next) => {
  try {
    const userId = req.body.userId;
    const data = await imageModel.findOne({ UserId: userId });

    if (!data) res.status(400).json({ errorMessage: 'Bad Request' });

    return await res
      .status(200)
      .json({ imageUrl: data.ImageUrl, id: data._id });
  } catch (error) {
    next(error);
  }
});

router.get('/', async (req, res, next) => {
  try {
    const message = { message: 'This is the index page 🚀🚀🚀' };
    res.status(200).json(message);
  } catch (error) {
    next(error);
  }
});

module.exports = router;
