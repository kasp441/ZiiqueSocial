import Keycloak from 'keycloak-js';

const keycloak = new Keycloak({
  url: 'http://localhost:8090',
  realm: 'ziiqueSocial',
  clientId: 'Ziique',
});


export default keycloak;