import React, { useState } from "react";
import ReactSelect from "react-select";
import {adduserToProcedure} from "../../../api/api";

const PlanProcedureItem = ({ procedure, users, Userlist, PlanId }) => {
   
const UserListArrayToValue = (userList) =>{
    let arr = [];
    if(userList != null){
      let List = JSON.parse(userList);
      List.forEach((ar)=> arr.push({label:ar.Name, value: ar.userId}));
    }
    return arr;
}
const [selectedUsers, setSelectedUsers] = useState(UserListArrayToValue(Userlist));

    const handleAssignUserToProcedure = (e) => {
        //setSelectedUsers(e);       
        // TODO: Remove console.log and add missing logic 

        if(e.length)  {     
        const updatedUser = e && adduserToProcedure(PlanId, procedure.procedureId,e[e.length -1].value);
        updatedUser && setSelectedUsers(updatedUser.Userlist);       
        }      
        else{
            setSelectedUsers(e);
        }
    };

    return (
        <div className="py-2">
            <div>
                {procedure.procedureTitle}
            </div>

            <ReactSelect
                className="mt-2"
                placeholder="Select User to Assign"
                isMulti={true}
                options={users}
                value={selectedUsers}
                onChange={(e) => handleAssignUserToProcedure(e)}
            />
        </div>
    );
};

export default PlanProcedureItem;
