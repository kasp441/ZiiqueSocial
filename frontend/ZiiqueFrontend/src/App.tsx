import "./App.css";
import { Route, Routes } from "react-router-dom";
import { Home } from "./pages/home";
import { useState } from "react";
import { Button } from "./components/ui/button";
import { ReactKeycloakProvider } from '@react-keycloak/web'
import keycloak from './keycloak'


const App = () => {
  return (
    <ReactKeycloakProvider authClient={keycloak}>
      <div className="App">
        <Routes>
          <Route path="/" element={<Home />} />
        </Routes>
      </div>
    </ReactKeycloakProvider>
  )
}

export default App;
