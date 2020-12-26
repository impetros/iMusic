/* 
 * iMusic DTOs
 *
 * iMusic
 *
 * OpenAPI spec version: 1.0.0
 * Contact: TODO: add iMusic email
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace iMusic.Dto.Model
{
    /// <summary>
    /// This object will be send to login
    /// </summary>
    [DataContract]
        public partial class LoginRequest :  IEquatable<LoginRequest>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRequest" /> class.
        /// </summary>
        /// <param name="emailOrUsername">emailOrUsername.</param>
        /// <param name="password">password.</param>
        public LoginRequest(string emailOrUsername = default(string), string password = default(string))
        {
            this.EmailOrUsername = emailOrUsername;
            this.Password = password;
        }
        
        /// <summary>
        /// Gets or Sets EmailOrUsername
        /// </summary>
        [DataMember(Name="emailOrUsername", EmitDefaultValue=false)]
        public string EmailOrUsername { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LoginRequest {\n");
            sb.Append("  EmailOrUsername: ").Append(EmailOrUsername).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as LoginRequest);
        }

        /// <summary>
        /// Returns true if LoginRequest instances are equal
        /// </summary>
        /// <param name="input">Instance of LoginRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LoginRequest input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EmailOrUsername == input.EmailOrUsername ||
                    (this.EmailOrUsername != null &&
                    this.EmailOrUsername.Equals(input.EmailOrUsername))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.EmailOrUsername != null)
                    hashCode = hashCode * 59 + this.EmailOrUsername.GetHashCode();
                if (this.Password != null)
                    hashCode = hashCode * 59 + this.Password.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
