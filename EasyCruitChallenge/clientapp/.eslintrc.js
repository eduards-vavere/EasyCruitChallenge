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
    'no-console': 0,
    'no-debugger': 0,
    'max-len': 0,
    'linebreak-style': 0,
    'no-alert': 0,
    'no-restricted-globals': 0,
  },
  parserOptions: {
    parser: 'babel-eslint',
  },
};
