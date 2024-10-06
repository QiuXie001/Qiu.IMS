import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44301/',
  redirectUri: baseUrl,
  clientId: 'IMS_App',
  responseType: 'code',
  scope: 'offline_access IMS',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'IMS',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44301',
      rootNamespace: 'Qiu.IMS',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
