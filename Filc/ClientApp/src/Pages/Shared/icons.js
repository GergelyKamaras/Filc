
import {IoIosHome, IoMdPerson, IoIosSchool } from 'react-icons/io';
import { GiArchiveRegister } from "react-icons/gi";
import { AiFillSnippets } from "react-icons/ai";
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
    else if(props.pageTitle === "User Registration" ||
            props.pageTitle === "Institutional registration"){
        return(
            <GiArchiveRegister className='icon'/>
        )
    }
    else if(props.pageTitle === "Institutional administrators" ||
            props.pageTitle === "Educational institutions" ||
            props.pageTitle === "Student directory" ||
            props.pageTitle === "Teacher directory"){
        return(
            <AiFillSnippets className='icon'/>
        )
    }
}

export default Icon;