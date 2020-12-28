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
    /// SongDTO
    /// </summary>
    [DataContract]
        public partial class SongDTO :  IEquatable<SongDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SongDTO" /> class.
        /// </summary>
        /// <param name="songId">songId.</param>
        /// <param name="name">name.</param>
        /// <param name="length">length.</param>
        /// <param name="price">price.</param>
        /// <param name="image">image.</param>
        /// <param name="artists">artists.</param>
        public SongDTO(decimal? songId = default(decimal?), string name = default(string), string length = default(string), float? price = default(float?), string image = default(string), List<ArtistDTO> artists = default(List<ArtistDTO>))
        {
            this.SongId = songId;
            this.Name = name;
            this.Length = length;
            this.Price = price;
            this.Image = image;
            this.Artists = artists;
        }
        
        /// <summary>
        /// Gets or Sets SongId
        /// </summary>
        [DataMember(Name="songId", EmitDefaultValue=false)]
        public decimal? SongId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Length
        /// </summary>
        [DataMember(Name="length", EmitDefaultValue=false)]
        public string Length { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public float? Price { get; set; }

        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name="image", EmitDefaultValue=false)]
        public string Image { get; set; }

        /// <summary>
        /// Gets or Sets Artists
        /// </summary>
        [DataMember(Name="artists", EmitDefaultValue=false)]
        public List<ArtistDTO> Artists { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SongDTO {\n");
            sb.Append("  SongId: ").Append(SongId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Length: ").Append(Length).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Artists: ").Append(Artists).Append("\n");
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
            return this.Equals(input as SongDTO);
        }

        /// <summary>
        /// Returns true if SongDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of SongDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SongDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SongId == input.SongId ||
                    (this.SongId != null &&
                    this.SongId.Equals(input.SongId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Length == input.Length ||
                    (this.Length != null &&
                    this.Length.Equals(input.Length))
                ) && 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) && 
                (
                    this.Artists == input.Artists ||
                    this.Artists != null &&
                    input.Artists != null &&
                    this.Artists.SequenceEqual(input.Artists)
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
                if (this.SongId != null)
                    hashCode = hashCode * 59 + this.SongId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Length != null)
                    hashCode = hashCode * 59 + this.Length.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.Artists != null)
                    hashCode = hashCode * 59 + this.Artists.GetHashCode();
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
