import React from "react";
import InnerProfil from "../components/IndexPageComponents/InnerProfil";
import '../Style/IndexPage/IndexPage.css'

const IndexPage = () => {
    return (
        <>
            <div className="index-parent">
                <div className="gov-news">
                    <div>
                        sajt
                    </div>
                     </div>
                <div className="profile">
                    <div className="profile-inner">
                        <InnerProfil logged={false}/>
                    </div>
                     </div>
                <div className="school-news">
                    sajt
                     </div>
                <div className="profile-functs">
                    sajt
                     </div>

            </div>
        </>
    );
};

export default IndexPage;