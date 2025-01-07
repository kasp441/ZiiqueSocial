import "./App.css";
import { Route, Routes } from "react-router-dom";
import { Home } from "./pages/home";
import { useState } from "react";
import { Button } from "./components/ui/button";
import { useKeycloak } from "@react-keycloak/web";
import keycloak from "./security";
import { Profile } from "./pages/profile";


function App() {
  const { keycloak } = useKeycloak();


  const handleLogout = () =>
  {
    keycloak.logout();
};

const handleLogin = () => {
  keycloak.login({
    prompt: "login",
  });
};

const button = keycloak.authenticated ? (
  <Button onClick={handleLogout}>Logout</Button>
) : (
  <Button onClick={handleLogin}>Login</Button>
);

return (
  <>
    <div className="bg-background">
      <div className="grid grid-cols-2 sticky top-10">
        <h1 className="justify-self-start box-decoration-clone bg-gradient-to-r from-indigo-600 to-pink-500 text-white px-2 rounded-md font-bold text-2xl">
          Ziique
          <br />
          Social
        </h1>
        <div className="justify-self-end">{button}</div>
      </div>
      <div className="pt-16">
        <Routes>
          <Route path="/home" element={<Home />} />
          <Route path="/profile/:id" element={<Profile />} />
        </Routes>
      </div>
    </div>
  </>
);
}

export default App;