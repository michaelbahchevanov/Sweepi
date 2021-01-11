const getUserId = () => {
  const data = JSON.parse(localStorage.getItem('user'));
  if (!data) return;
  return data.userId;
};

export { getUserId };
