import { useNavigate } from "react-router-dom";
import "./styles/LandingPage.css";

function LandingPage() {
    const navigate = useNavigate();

    return (
        <div className="landing">
            <div className="landing-content">
                <h1>Welcome to MessageIt</h1>

                <p>
                    Experience secure, real-time messaging with a clean and
                    intuitive interface. Stay connected with friends, family,
                    and teams from anywhere.
                </p>

                <button onClick={() => navigate("/home")}> 
                    Get Started
                </button>
            </div>
        </div>
    );
}

export default LandingPage;