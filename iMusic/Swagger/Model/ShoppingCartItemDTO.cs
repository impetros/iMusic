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
    /// ShoppingCartItemDTO
    /// </summary>
    [DataContract]
        public partial class ShoppingCartItemDTO :  IEquatable<ShoppingCartItemDTO>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartItemDTO" /> class.
        /// </summary>
        /// <param name="price">price.</param>
        /// <param name="albumId">albumId.</param>
        /// <param name="album">album.</param>
        /// <param name="songId">songId.</param>
        /// <param name="song">song.</param>
        public ShoppingCartItemDTO(float? price = default(float?), decimal? albumId = default(decimal?), AlbumDTO album = default(AlbumDTO), decimal? songId = default(decimal?), SongDTO song = default(SongDTO))
        {
            this.Price = price;
            this.AlbumId = albumId;
            this.Album = album;
            this.SongId = songId;
            this.Song = song;
        }
        
        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public float? Price { get; set; }

        /// <summary>
        /// Gets or Sets AlbumId
        /// </summary>
        [DataMember(Name="albumId", EmitDefaultValue=false)]
        public decimal? AlbumId { get; set; }

        /// <summary>
        /// Gets or Sets Album
        /// </summary>
        [DataMember(Name="album", EmitDefaultValue=false)]
        public AlbumDTO Album { get; set; }

        /// <summary>
        /// Gets or Sets SongId
        /// </summary>
        [DataMember(Name="songId", EmitDefaultValue=false)]
        public decimal? SongId { get; set; }

        /// <summary>
        /// Gets or Sets Song
        /// </summary>
        [DataMember(Name="song", EmitDefaultValue=false)]
        public SongDTO Song { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShoppingCartItemDTO {\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  AlbumId: ").Append(AlbumId).Append("\n");
            sb.Append("  Album: ").Append(Album).Append("\n");
            sb.Append("  SongId: ").Append(SongId).Append("\n");
            sb.Append("  Song: ").Append(Song).Append("\n");
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
            return this.Equals(input as ShoppingCartItemDTO);
        }

        /// <summary>
        /// Returns true if ShoppingCartItemDTO instances are equal
        /// </summary>
        /// <param name="input">Instance of ShoppingCartItemDTO to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShoppingCartItemDTO input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.AlbumId == input.AlbumId ||
                    (this.AlbumId != null &&
                    this.AlbumId.Equals(input.AlbumId))
                ) && 
                (
                    this.Album == input.Album ||
                    (this.Album != null &&
                    this.Album.Equals(input.Album))
                ) && 
                (
                    this.SongId == input.SongId ||
                    (this.SongId != null &&
                    this.SongId.Equals(input.SongId))
                ) && 
                (
                    this.Song == input.Song ||
                    (this.Song != null &&
                    this.Song.Equals(input.Song))
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
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.AlbumId != null)
                    hashCode = hashCode * 59 + this.AlbumId.GetHashCode();
                if (this.Album != null)
                    hashCode = hashCode * 59 + this.Album.GetHashCode();
                if (this.SongId != null)
                    hashCode = hashCode * 59 + this.SongId.GetHashCode();
                if (this.Song != null)
                    hashCode = hashCode * 59 + this.Song.GetHashCode();
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
