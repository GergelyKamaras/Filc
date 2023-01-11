
import {IoIosHome, IoMdPerson, IoIosSchool } from 'react-icons/io';
import { GiArchiveRegister } from "react-icons/gi";

const Icon = (props) =>{
    console.log(props.pageTitle)
    if(props.pageTitle === "Home page"){
        return (
            <IoIosHome className='icon'/>
        )
    }
    else if (props.pageTitle === "Profile page"){
        return(
            <IoMdPerson className='icon'/>
        )
    }
    else if(props.pageTitle === "School Details"){
        return(
            <IoIosSchool className="icon"/>
        )
    }
    else if(props.pageTitle === "User Registration"){
        return(
            <GiArchiveRegister className='icon'/>
        )
    }
}

export default Icon;