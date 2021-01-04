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

router.get('/images/:id', async (req, res, next) => {
  try {
    const imageId = req.params.id;

    imageModel
      .findById(imageId)
      .then((data) => res.status(200).json({ imageUrl: data.ImageUrl }))
      .catch(() => {
        res.status(404).json({ errorMessage: 'Not found' });
      });
  } catch (error) {
    next(error);
  }
});

router.post('/images/all', async (req, res, next) => {
  try {
    const userId = req.body.userId;
    const user = await imageModel.findOne({ UserId: userId });

    if (!user) res.status(401).json({ errorMessage: 'Bad Request' });

    return await res.status(200).json({ imageUrl: user.ImageUrl });
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
