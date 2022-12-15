
import '../../Style/IndexPage/IndexPage.css'
import News from './News'
import LoginForm from "../Login/LoginUser";
import React from "react";

const IndexPage = ({loginStatus, updateLoginStatus}) => {


    return (
        <>
            <div className="index-parent">
                <div className="gov-news">
                    <News/>
                </div>
                <div className="profile">
                    <div className="profile-inner">
                        <LoginForm loginStatus={loginStatus} updateLoginStatus={updateLoginStatus}/>
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