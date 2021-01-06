import axios from 'axios';

const fakeData = [
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5471',
    imageUrl:
      'https://ucarecdn.com/a1a9632f-13fd-4f5b-928f-1a5c189d38e7/882903.jpg',
    name: 'Charger',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5472',
    imageUrl: 'https://picsum.photos/400',
    name: 'Beans',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5473',
    imageUrl: 'https://picsum.photos/500',
    name: 'Apples',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5474',
    imageUrl: 'https://picsum.photos/600',
    name: 'Bananas',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5475',
    imageUrl: 'https://picsum.photos/400',
    name: 'Oranges',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5476',
    imageUrl: 'https://picsum.photos/500',
    name: 'Tangerines',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5477',
    imageUrl: 'https://picsum.photos/700',
    name: 'Phone',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5478',
    imageUrl: 'https://picsum.photos/700',
    name: 'Pears',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5479',
    imageUrl: 'https://picsum.photos/400',
    name: 'Socks',
  },
  {
    id: '6d48aed5-d66d-46d6-a7b9-c396404f5480',
    imageUrl: 'https://picsum.photos/400',
    name: 'Potatoes',
  },
];

const URL = '';

const getMedia = async () => {
  return await fakeData;
};

export { getMedia };
