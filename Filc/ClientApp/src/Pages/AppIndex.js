
import InnerProfil from "../components/IndexPageComponents/InnerProfil";
import '../Style/IndexPage/IndexPage.css'
import News from '../components/IndexPageComponents/News'

const IndexPage = () => {


    return (
        <>
            <div className="index-parent">
                <div className="gov-news">
                    <News/>
                </div>
                <div className="profile">
                    <div className="profile-inner">
                        <InnerProfil/>
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