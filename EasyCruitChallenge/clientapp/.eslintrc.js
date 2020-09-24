module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: [
    'plugin:vue/essential',
    '@vue/airbnb',
  ],
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'error' : 'off',
    'max-len': 0,
    'linebreak-style': 0,
    'no-alert': 0,
    'no-restricted-globals': 0,
  },
  parserOptions: {
    parser: 'babel-eslint',
  },
};
