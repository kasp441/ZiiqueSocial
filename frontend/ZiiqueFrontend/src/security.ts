import Keycloak from 'keycloak-js';

const keycloak = new Keycloak({
  url: 'https://localhost:8090',
  realm: 'ziiqueSocial',
  clientId: 'ZiiqueSocial'
});

export default keycloak;