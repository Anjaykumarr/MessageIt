import { useState, useEffect } from "react";
import { routes } from "../api/routeService";
import "./styles/LandingPage.css";

function LandingPage() {

    
    const [buttons, setButtons] = useState([]);
    
    const loadButtons = async () => {
        try {
            const response = await routes.getButtons();
            
            setButtons(response.data);
        } catch (error) {
            console.error(error);
        }
    };
    
    useEffect(() => {
        loadButtons();
    }, []);

    return (
        <div className="landing">
            <div className="landing-content">
                <h1>Welcome to MessageIt</h1>

                <p>
                    Experience secure, real-time messaging with a clean and
                    intuitive interface. Stay connected with friends, family,
                    and teams from anywhere.
                </p>

                <button onClick={() => rorutes.nextPage()}> 
                    Get Started
                </button>
            </div>
        </div>
    );
}

export default LandingPage;