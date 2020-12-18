const { Router } = require('express');
const imageModel = require('../../models/Image');

const router = Router();

router.post('/images', async (req, res, next) => {
  try {
    const data = req.body;
    const image = new imageModel({
      UserId: 'yes-no',
      ProductId: 'yes-no-yes',
      ImageUrl: data.imageUrl,
    });
    const createdEntry = await image.save();
    res.json(createdEntry);
  } catch (error) {
    next(error);
  }
});

module.exports = router;
