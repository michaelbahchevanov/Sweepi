const LocalStorageService = (function () {
  var _service;

  function _getService() {
    if (!_service) {
      _service = this;
      return _service;
    }
    return _service;
  }

  function _setToken(data) {
    localStorage.setItem('user', JSON.stringify(data));
  }

  function _getToken() {
    let user = JSON.parse(localStorage.getItem('user'));
    if (user && user.token) return user.token;
    return null;
  }

  function _getRefreshToken() {
    let user = JSON.parse(localStorage.getItem('user'));
    if (user && user.refreshToken) return user.refreshToken;
    return null;
  }

  function _clearToken() {
    localStorage.removeItem('user');
  }

  return {
    getService: _getService,
    setToken: _setToken,
    getToken: _getToken,
    getRefreshToken: _getRefreshToken,
    clearToken: _clearToken,
  };
})();

export default LocalStorageService;
