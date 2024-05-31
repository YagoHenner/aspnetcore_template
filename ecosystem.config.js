module.exports = {
  apps: [
    {
      name: 'back-dev-start',
      script: 'dist/server.js',
      watch: true,
      ignore_watch: ['node_modules'],
    },
  ],
};
