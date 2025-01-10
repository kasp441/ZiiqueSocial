import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import App from "./App.tsx";
import "./index.css";
import { BrowserRouter } from "react-router-dom";
import keycloak from "./security.ts";
import { ReactKeycloakProvider } from "@react-keycloak/web";
import { GlobalStateFollowersProvider } from "./components/helpers/globalStateContext.tsx";

createRoot(document.getElementById("root")!).render(
  <ReactKeycloakProvider authClient={keycloak}>
    <StrictMode>
      <BrowserRouter>
        <GlobalStateFollowersProvider>
          <App />
        </GlobalStateFollowersProvider>
      </BrowserRouter>
    </StrictMode>
  </ReactKeycloakProvider>
);
