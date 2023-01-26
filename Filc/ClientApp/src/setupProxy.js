const { createProxyMiddleware } = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://172.104.238.6:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://172.104.238.6:3616';

const context =  [
    "/weatherforecast",
    "/api",
    "/gov"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware( {
      target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use("/kiskutya", appProxy);
};
