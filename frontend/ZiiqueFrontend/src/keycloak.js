import keycloak from 'keycloak-js';

const keycloakConfig = {
    realm: "ZiiqueSocial",
    url: "http://localhost:8090/auth",
    clientId: "ZiiqueSocial",
  };

const keycloakInstance = keycloak(keycloakConfig);

export default keycloakInstance;