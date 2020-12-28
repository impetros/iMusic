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
    /// AlbumDTO
    /// </summary>
    [DataContract]
        public partial class AlbumDTO :  IEquatable<AlbumDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumDTO" /> class.
        /// </summary>
        /// <param name="albumId">albumId.</param>
        /// <param name="name">name.</param>
        /// <param name="price">price.</param>
        /// <param name="image">image.</param>
        /// <param name="songs">songs.</param>
        public AlbumDTO(decimal? albumId = default(decimal?), string name = default(string), float? price = default(float?), string image = default(string), List<SongDTO> songs = default(List<SongDTO>))
        {
            this.AlbumId = albumId;
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.Songs = songs;
        }
        
        /// <summary>
        /// Gets or Sets AlbumId
        /// </summary>
        [DataMember(Name="albumId", EmitDefaultValue=false)]
        public decimal? AlbumId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

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
        /// Gets or Sets Songs
        /// </summary>
        [DataMember(Name="songs", EmitDefaultValue=false)]
        public List<SongDTO> Songs { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AlbumDTO {\n");
            sb.Append("  AlbumId: ").Append(AlbumId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  Songs: ").Append(Songs).Append("\n");
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
            return this.Equals(input as AlbumDTO);
        }

        /// <summary>
        /// Returns true if AlbumDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of AlbumDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AlbumDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AlbumId == input.AlbumId ||
                    (this.AlbumId != null &&
                    this.AlbumId.Equals(input.AlbumId))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                    this.Songs == input.Songs ||
                    this.Songs != null &&
                    input.Songs != null &&
                    this.Songs.SequenceEqual(input.Songs)
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
                if (this.AlbumId != null)
                    hashCode = hashCode * 59 + this.AlbumId.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.Songs != null)
                    hashCode = hashCode * 59 + this.Songs.GetHashCode();
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
