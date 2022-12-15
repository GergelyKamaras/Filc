
import '../../Style/IndexPage/IndexPage.css'
import News from './News'
import LoginForm from "../Login/LoginUser";

const IndexPage = () => {


    return (
        <>
            <div className="index-parent">
                <div className="gov-news">
                    <News/>
                </div>
                <div className="profile">
                    <div className="profile-inner">
                        <LoginForm/>
                    </div>
                </div>
                <div className="school-news">
                </div>
                <div className="profile-functs">
                    
                </div>
            </div>
            
        </>
    );
};

export default IndexPage;