import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import { BrowserRouter } from 'react-router-dom'
import keycloak from './security.ts'
import {ReactKeycloakProvider} from '@react-keycloak/web'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ReactKeycloakProvider authClient={keycloak}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
    </ReactKeycloakProvider>
  </StrictMode>,
)

