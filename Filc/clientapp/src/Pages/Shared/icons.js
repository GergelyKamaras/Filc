
import {IoIosHome, IoMdPerson, IoIosSchool } from 'react-icons/io';
import { GiArchiveRegister, GiUpgrade } from "react-icons/gi";
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
    else if(props.pageTitle === "School details"){
        return(
            <IoIosSchool className="icon"/>
        )
    }
    else if(props.pageTitle === "User registration" ||
            props.pageTitle === "Institutional registration" ||
            props.pageTitle === "Subject registration" || 
            props.pageTitle === "Lesson registration"){
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
    else if(props.pageTitle === "Student grading"){
        return(
            <GiUpgrade className='icon'/>
        )
    }
}

export default Icon;