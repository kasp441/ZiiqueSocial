import "./App.css";
import { Route, Routes, useNavigate } from "react-router-dom";
import { Home } from "./pages/home";
import { Button } from "./components/ui/button";
import { useKeycloak } from "@react-keycloak/web";
import { Profile } from "./pages/profile";
import { CheckCreation } from "./pages/checkCreation";
import { ProfileCreation } from "./pages/profileCreation";


function App() {
  const { keycloak } = useKeycloak();
  const navigate = useNavigate();


  const handleLogout = () =>
  {
    keycloak.logout();
};

const handleLogin = () => {
  keycloak.login({
    prompt: "login",
    redirectUri: window.location.origin + "/check",
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
        <h1 onClick={() => {navigate("/home")}} className="justify-self-start box-decoration-clone bg-gradient-to-r from-indigo-600 to-pink-500 text-white px-2 rounded-md font-bold text-2xl cursor-pointer">
          Ziique
          <br />
          Social
        </h1>
        <div className="justify-self-end">{button}</div>
      </div>
      <div className="pt-16">
        { !keycloak.didInitialize ? (
          <div>Loading...</div>
        ) : (
          <>
            <Routes>
              <Route path="/home" element={<Home />} />
              <Route path="/profile/:id" element={<Profile />} />
              <Route path="/check" element={<CheckCreation />} />
              <Route path="/newprofile" element={<ProfileCreation />} />
            </Routes>
          </>
        )}
      </div>
    </div>
  </>
);
}

export default App;