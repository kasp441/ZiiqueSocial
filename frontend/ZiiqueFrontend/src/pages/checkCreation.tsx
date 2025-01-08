import { useKeycloak } from "@react-keycloak/web";
import { profileService } from "@/components/services/profileService";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

export function CheckCreation() {
    const { keycloak } = useKeycloak(); 
    const navigate = useNavigate(); 

    useEffect(() => {
        profileService.checkIfUserExists(keycloak.subject!).then((result) => {
            if (result) {
                navigate("/home");
            } else {
                navigate("/newprofile");
            }
        });
    }, [keycloak.subject, navigate]);

    return (
        <>
        </>
    )
}