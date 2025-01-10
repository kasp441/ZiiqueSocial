import { createContext, useContext, useState } from "react";

type GlobalStateFollowers = {
    followers: string[];
    setFollowers: (followers: string[]) => void;
};

const GlobalStateFollowersContext = createContext<GlobalStateFollowers | undefined>(undefined);

export const GlobalStateFollowersProvider = ({ children }: { children: React.ReactNode }) => {  
    const [followers, setFollowers] = useState<string[]>([]);

    return (
        <GlobalStateFollowersContext.Provider value={{ followers, setFollowers }}>
            {children}
        </GlobalStateFollowersContext.Provider>
    );
};

export const useGlobalStateFollowers = () => {
    const context = useContext(GlobalStateFollowersContext);
    if (context === undefined) {
        throw new Error('useGlobalStateFollowers must be used within a GlobalStateFollowersProvider');
    }
    return context;
};