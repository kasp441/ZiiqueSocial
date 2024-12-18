import './App.css'
import { useAuth0 } from '@auth0/auth0-react';
import "./App.css";
import { Route, Routes } from "react-router-dom";
import { Home } from "./pages/home";
import { Button } from "./components/ui/button";

function App() {
  const { loginWithRedirect, logout, isAuthenticated } = useAuth0();

  const button = isAuthenticated ? (
    <Button onClick={() => logout()}>Logout</Button>
  ) : (
    <Button onClick={() => loginWithRedirect()}>Login</Button>
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
            <Route path="/" element={<Home />} />
          </Routes>
        </div>
      </div>
    </>
  );
}

export default App;
