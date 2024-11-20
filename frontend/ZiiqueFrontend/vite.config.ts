import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
/** USED FOR RESOLVING UKNOWN PATHS FOR SHADCN UI COMPONENTS **/
import path from 'node:path'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      "@": path.resolve(__dirname, "./src"),
    },
  },
})
