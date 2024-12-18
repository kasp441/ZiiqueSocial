import './App.css'
import { useAuth0 } from '@auth0/auth0-react';

function App() {
  const { loginWithRedirect, logout, user, isAuthenticated, isLoading } = useAuth0();

  return (
    <>
      <button onClick={() => loginWithRedirect()}>Log In</button>
      <button onClick={() => logout()}>Log Out</button>

      {isLoading && <p>Loading...</p>}
      {isAuthenticated && (
        <div>
          <p>Hello, {user?.name}</p>
          <p>Email: {user?.email}</p>
        </div>
      )}
    </>
  )
}

export default App
