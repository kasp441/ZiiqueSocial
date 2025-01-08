import Keycloak from 'keycloak-js';

const keycloak = new Keycloak({
  url: 'http://localhost:8080',
  realm: 'ziiqueSocial',
  clientId: 'Ziique',
});


export default keycloak;