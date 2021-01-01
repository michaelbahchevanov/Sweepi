const path = require('path');

module.exports = {
  webpack: {
    alias: {
      '@components': path.resolve(__dirname, 'src/components'),
      '@pages': path.resolve(__dirname, 'src/pages'),
      '@services': path.resolve(__dirname, 'src/services'),
      '@helpers': path.resolve(__dirname, 'src/helpers'),
      '@context': path.resolve(__dirname, 'src/context'),
    },
  },
  jest: {
    configure: {
      moduleNameMapper: {
        '^@components(.*)$': '<rootDir>/src/components$1',
      },
    },
  },
  style: {
    postcss: {
      plugins: [require('tailwindcss'), require('autoprefixer')],
    },
  },
};
