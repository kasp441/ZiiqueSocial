import keycloak from "@/security";
import axios from "axios";

const axiosInstance = axios.create({
    baseURL: 'http://localhost:8090',
}); 

axiosInstance.interceptors.request.use(
    (config) => {
        const token = keycloak.token;
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default axiosInstance;