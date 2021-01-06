const getUserId = async () => {
  const data = await JSON.parse(localStorage.getItem('user'));
  return data.userId;
};

export { getUserId };
